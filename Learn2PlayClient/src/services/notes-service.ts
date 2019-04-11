import { LogManager, autoinject } from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import {INote} from "../interfaces/INote";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('NotesService');

@autoinject
export class NotesService extends BaseService<INote> {
  constructor(
    private httpCliet: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpCliet, appConfig, 'Notes');
  }
}
