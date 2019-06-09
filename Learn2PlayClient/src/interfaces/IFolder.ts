import {IBaseEntity} from "./IBaseEntity";
import { ISong } from "./ISong";

export interface IFolder extends IBaseEntity {
  name: string;
  folderType: string;
  comment: string;
  songs: ISong[];
}
