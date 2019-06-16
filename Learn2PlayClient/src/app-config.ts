import {LogManager, autoinject} from "aurelia-framework";
import {INote} from "./interfaces/INote";
import {IChord} from "./interfaces/IChord";
import {ISong} from "./interfaces/ISong";
import {ISongWithEverything} from "./interfaces/ISongWithEverything";
import {IFolder} from "./interfaces/IFolder";

export var log = LogManager.getLogger('AppConfig');

@autoinject
export class AppConfig {
  
  public apiUrl = 'https://learn2play-javalg.azurewebsites.net/api/v1.0/'; // localhost:5001/api/v1.0/ for local hosting
  public jwt: string | null = null;

  constructor() {
    log.debug('constructor');
  }

}
