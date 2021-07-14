import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BaseService } from './base.service';
import { Release } from '../models/release.model';
import { FrontParams } from '../models/frontParams.model';

@Injectable({
  providedIn: 'root'
})
export class ReleaseService extends BaseService {

  private urlRelease: string;

  constructor(http: HttpClient) {
    super(http);
    this.urlRelease = environment.urlAPI + 'ReleaseData';
  }

  public getAllReleases(): Observable<any> {
    return this.get(`${this.urlRelease}`);
  }

  public getById(id: number): Observable<any> {
    return this.get(`${this.urlRelease}/${id}`);
  }

  public getReleaseByProject(idProject: number): Observable<any> {
    return this.get(`${this.urlRelease}/getReleaseByProject/${idProject}`);
  }

  public createRelease(forntP: any) {
    return this.post(`${this.urlRelease}/CreateRelease`, forntP);
  }

}
