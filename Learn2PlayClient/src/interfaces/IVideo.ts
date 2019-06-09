import {IBaseEntity} from "./IBaseEntity";

export interface IVideo extends IBaseEntity {
  youTubeUrl: string;
  authorChannelLink: string;
  localPath: string;
}
