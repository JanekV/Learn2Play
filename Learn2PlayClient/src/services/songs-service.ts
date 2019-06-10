import { ISongWithEverything } from './../interfaces/ISongWithEverything';
import { LogManager, autoinject } from 'aurelia-framework';
import {HttpClient} from 'aurelia-fetch-client';
import {ISong} from "../interfaces/ISong";
import {BaseService} from "./base-service";
import {AppConfig} from "../app-config";

export var log = LogManager.getLogger('SongsService');

@autoinject
export class SongsService extends BaseService<ISong> {
  constructor(
    private httpClient: HttpClient,
    private appConfig: AppConfig
  ) {
    super(httpClient, appConfig, 'Songs');
  }

  // get song with everything
  async fetchSWE(id: number): Promise<ISongWithEverything> {
    let url = this.appConfig.apiUrl + 'Songs/' + id;

    try {
      const response = await this.httpClient.fetch(url, {
        cache: 'no-store',
        headers: {
          Authorization: 'Bearer ' + this.appConfig.jwt,
        }
      });
      log.debug('resonse', response);
      const jsonData = await response.json();
      log.debug('jsonData', jsonData);
      return jsonData;
    }
    catch (reason) {
      log.debug('catch reason', reason);
    }
  }

  // Given song and folder id's, put song in folder
  async putSongInFolder(songId: number, folderIds: number[]): Promise<Response> {
    let url = this.appConfig.apiUrl + 'Songs/' + songId;

    const response = await this.httpClient.put(url, JSON.stringify(folderIds), {
      cache: 'no-store',
      headers: {
        Authorization: 'Bearer ' + this.appConfig.jwt,
      }
    });
    log.debug('response', response);
    return response;

  }
}
