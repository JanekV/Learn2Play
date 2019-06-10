import { LogManager, autoinject } from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import {IFolder} from "../interfaces/IFolder";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('FoldersService');

@autoinject
export class FoldersService extends BaseService<IFolder> {
  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Folders');
  }

  async removeSong(songId: number, folderId: number): Promise<Response> {
    let url = this.appConfig.apiUrl +'Folders/' + songId + '/' + folderId;

    const response = await this.httpClient.delete(url, {
      cache: 'no-store',
      headers: {
        Authorization: 'Bearer ' + this.appConfig.jwt,
      }
    });
    log.debug('response', response);
    return response;
  }
}
