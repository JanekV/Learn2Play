import { LogManager, autoinject } from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import {ISongWithEverything} from "../interfaces/ISongWithEverything";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('ISongWithEverythingService');

@autoinject
export class SongWithEverythingService extends BaseService<ISongWithEverything> {
  constructor(
    private httpCliet: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpCliet, appConfig, 'SongWithEveryThing');
  }
}
