# Welcome to Harmony

  Harmony is a tool for writing piano pieces using a dedicated language.

  ![alt text](https://i.imgur.com/Zd3DzsO.png)
    
  > You can download Pre-Release on this repo.
  
# Exemple

  ```
  name : Exemple1
  author : Skinz
  tempo : 80

  unit main
  {
	  step 1 // silence of 1 bar
	  step notes C#3,F3,G#3,C4,F4,G#4 (4,100).strum(7).transpose(4) 
	  step notes G#2,D#3,F#3,A#3,C4,D#4,F#4  (4,100).propagate(1).arpeggio(forward).transpose(4)
	  step chord C#maj7 (4,100,4).propagate(2).arpeggio(forward)
  }
  ```
# Harmony Language

## Statements

 | Keyword      | Parameters    | Description    |
| ------------- |:-------------:| :-------------:|
| step      | Wait for the end of the instruction or the specified time to go to the next line  | 
| notes | Play a set of notes  |
| note | Play a note |
| chord | Joue un accord | 
| AMQP | *     |   
| ExpressJs | * |
| body-parser | * | 
| uuid | * |
| StompJs      |
| D3Js | 4.0 |
| Bootstrap | 5.0.1 |


## Keywords


# Technologies

  * SFMF .NET 2.5.1
  * Microsoft WPF
  * NAudio
  * Newtonsoft.Json
  * AvalonEdit
  * Antlr4
  * PresentationFramework.Aero
  * Presentation Core