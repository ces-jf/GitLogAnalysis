import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient} from '@angular/common/http';
import { Candidato } from './candidato.model';

@Injectable({
  providedIn: 'root'
})
export class CandidatoServiceService {

  private url = 'http://localhost:5000/api/Candidato';


constructor(private http: HttpClient) { }

getUsers(): Observable<any> {
  return this.http.get<any>(this.url);
}

get(id: number): Observable<any> {
  return this.http.get(`${this.url}/${id}`);
}

createCandidato(candidato: Candidato): Observable<Object> {
  return this.http.post(`${this.url}`, candidato);
}

updateCandidato(id: number, value: any): Observable<Object> {
  return this.http.put(`${this.url}`, value);
}

deleteCandidato(id: number): Observable<any> {
  return this.http.delete(`${this.url}/${id}`, { responseType: 'text' });
}

exibirResultados(numVagas: any) {
  return this.http.put(this.url + '/RecalcularVagas/' + numVagas, null);
}

}
