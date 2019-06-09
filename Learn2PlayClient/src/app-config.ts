import {LogManager, autoinject} from "aurelia-framework";
import {INote} from "./interfaces/INote";
import {IChord} from "./interfaces/IChord";
import {ISong} from "./interfaces/ISong";
import {ISongWithEverything} from "./interfaces/ISongWithEverything";
import {IFolder} from "./interfaces/IFolder";

export var log = LogManager.getLogger('AppConfig');

@autoinject
export class AppConfig {
  
  public apiUrl = 'https://localhost:5001/api/v1.0/';
  public jwt: string | null = null;

  constructor() {
    log.debug('constructor');
  }

}
