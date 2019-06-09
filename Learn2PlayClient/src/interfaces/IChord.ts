import {IBaseEntity} from "./IBaseEntity";
import { INote } from "./INote";

export interface IChord extends IBaseEntity {
  name: string;
  shapePicturePath: string;
  notes: INote[];
}
