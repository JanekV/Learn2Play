import { LogManager, autoinject } from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import {IChord} from "../interfaces/IChord";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('ChordsService');

@autoinject
export class ChordsService extends BaseService<IChord> {
  constructor(
    private httpCliet: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpCliet, appConfig, 'Chords');
  }
}
