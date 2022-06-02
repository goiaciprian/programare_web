import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Apartament } from '../models/apartament.model';
import { ApartamentDTO } from '../models/apartamentdto.model';
import { User } from '../models/user.model.ts';

@Injectable({
  providedIn: 'root',
})
export class ApartamenteService {
  private readonly base: string = 'http://localhost:8086/api';

  constructor(private _http: HttpClient) {}

  public getAllUsers(): Observable<User[]> {
    return this._http.get<User[]>(`${this.base}/users`);
  }

  public getAllApartaments(): Observable<Apartament[]> {
    return this._http.get<Apartament[]>(`${this.base}/apartamente`);
  }

  public createApartament(apartament: ApartamentDTO) {
    return this._http.post<Apartament>(`${this.base}/apartamente`, apartament);
  }

  public deleteApartament(id: number) {
    return this._http.delete<Apartament>(`${this.base}/apartamente/${id}`);
  }
}
