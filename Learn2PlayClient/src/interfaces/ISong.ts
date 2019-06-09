import {IBaseEntity} from "./IBaseEntity";

export interface ISong extends IBaseEntity {
  name: string;
  author: string;
  spotifyLink: string;
}
