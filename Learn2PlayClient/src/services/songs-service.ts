import { LogManager, autoinject } from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import {ISong} from "../interfaces/ISong";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('SongsService');

@autoinject
export class SongsService extends BaseService<ISong> {
  constructor(
    private httpCliet: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpCliet, appConfig, 'Songs');
  }
}
