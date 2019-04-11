import {LogManager, autoinject} from "aurelia-framework";
import {INote} from "./interfaces/INote";
import {IChord} from "./interfaces/IChord";

export var log = LogManager.getLogger('AppConfig');

@autoinject
export class AppConfig {
  
  public apiUrl = 'https://localhost:5001/api/';
  public jwt: string | null = null;

  constructor() {
    log.debug('constructor');
  }

}
