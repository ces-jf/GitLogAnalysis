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
export class ProjectService extends BaseService {

    private urlApi: string;

    constructor(http: HttpClient) {
        super(http);
        this.urlApi = environment.urlAPI + 'Project';
    }

    public getAllProjects(): Observable<any> {
        return this.get(`${this.urlApi}`);
    }

    public getProjectById(id: number): Observable<any> {
        return this.get(`${this.urlApi}/${id}`);
    }

    public createProject(projectP: any) {
        return this.post(`${this.urlApi}/CreateProject`, projectP);
    }
}