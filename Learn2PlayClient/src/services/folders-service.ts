import { LogManager, autoinject } from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import {IFolder} from "../interfaces/IFolder";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('FoldersService');

@autoinject
export class FoldersService extends BaseService<IFolder> {
  constructor(
    private httpCliet: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpCliet, appConfig, 'Folders');
  }
}
