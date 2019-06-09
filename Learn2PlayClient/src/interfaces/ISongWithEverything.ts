import {IBaseEntity} from "./IBaseEntity";
import { IInstrument } from "./IInstrument";
import { IStyle } from "./IStyle";
import { IChord } from "./IChord";
import { IVideo } from "./IVideo";

export interface ISongWithEverything extends IBaseEntity {
  name: string;
  author: string;
  spotifyLink: string;
  description: string;
  songKeyDescription: string;
  songKeyNote: string;

  instruments: IInstrument[];
  styles: IStyle[];
  chords: IChord[];
  video: IVideo[];
}
