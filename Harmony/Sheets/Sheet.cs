using NAudio.Midi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Harmony.Sheets
{
    public class Sheet
    {
        public List<SheetNote> Notes
        {
            get;
            private set;
        }
        private MidiFile File
        {
            get;
            set;
        }
        public float TotalDuration
        {
            get;
            private set;
        }
        public Sheet(string midiFilePath)
        {
            this.File = new MidiFile(midiFilePath);
            this.Notes = new List<SheetNote>();
        }
        public void Open()
        {
            File.Events.MidiFileType = 0;

            // Have just one collection for both non-note-off and tempo change events
            List<MidiEvent> midiEvents = new List<MidiEvent>();

            for (int n = 0; n < File.Tracks; n++)
            {
                foreach (var midiEvent in File.Events[n])
                {
                    //  if (!MidiEvent.IsNoteOff(midiEvent))
                    {
                        midiEvents.Add(midiEvent);

                        // Instead of causing stack unwinding with try/catch,
                        // we just test if the event is of type TempoEvent
                        if (midiEvent is TempoEvent)
                        {
                            Console.Write("Absolute Time " + (midiEvent as TempoEvent).AbsoluteTime);
                        }
                    }
                }
            }

            // Switch to decimal from float.
            // decimal has 28-29 digits percision
            // while float has only 6-9
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types

            // Now we have only one collection of both non-note-off and tempo events
            // so we cannot be sure of the size of the time values array.
            // Just employ a List<float>
            Dictionary<MidiEvent, decimal> eventsTimes = new Dictionary<MidiEvent, decimal>();

            // Keep track of the last absolute time and last real time because
            // tempo events also can occur "between" events
            // which can cause incorrect times when calculated using AbsoluteTime
            decimal lastRealTime = 0m;
            decimal lastAbsoluteTime = 0m;

            // instead of keeping the tempo event itself, and
            // instead of multiplying every time, just keep
            // the current value for microseconds per tick
            decimal currentMicroSecondsPerTick = 0m;

            for (int i = 0; i < midiEvents.Count; i++)
            {
                MidiEvent midiEvent = midiEvents[i];
                TempoEvent tempoEvent = midiEvent as TempoEvent;

                // Just append to last real time the microseconds passed
                // since the last event (DeltaTime * MicroSecondsPerTick
                if (midiEvent.AbsoluteTime > lastAbsoluteTime)
                {
                    lastRealTime += ((decimal)midiEvent.AbsoluteTime - lastAbsoluteTime) * currentMicroSecondsPerTick;
                }

                lastAbsoluteTime = midiEvent.AbsoluteTime;

                if (tempoEvent != null)
                {
                    // Recalculate microseconds per tick
                    currentMicroSecondsPerTick = (decimal)tempoEvent.MicrosecondsPerQuarterNote / (decimal)File.DeltaTicksPerQuarterNote;

                    // Remove the tempo event to make events and timings match - index-wise
                    // Do not add to the eventTimes
                    midiEvents.RemoveAt(i);
                    i--;
                    continue;
                }

                // Add the time to the collection.
                eventsTimes.Add(midiEvent, lastRealTime / 1000000m);
            }

            var endTrackEvent = eventsTimes.Keys.OfType<MetaEvent>().FirstOrDefault(x => x.MetaEventType == MetaEventType.EndTrack);

            this.TotalDuration = (float)eventsTimes[endTrackEvent];

            eventsTimes = eventsTimes.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var noteOnEvent in eventsTimes.Keys.OfType<NoteOnEvent>())
            {
                float start = (float)eventsTimes[noteOnEvent];

                float end = start + 0.2f;

                if (noteOnEvent.OffEvent != null)
                {
                    end = (float)eventsTimes[noteOnEvent.OffEvent];
                }

                SheetNote note = new SheetNote(noteOnEvent.NoteNumber - 20, start, end, noteOnEvent.Velocity);
                Notes.Add(note);
            }
        }
    }
}
