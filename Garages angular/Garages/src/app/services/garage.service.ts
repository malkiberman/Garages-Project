import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Garage } from '../models/garage.interface';

@Injectable({
  providedIn: 'root'
})
export class GarageApiService {
  private apiUrl = 'https://garages-project-api.onrender.com/api/Garage'; 

  constructor(private http: HttpClient) { }

  fetchGaragesFromExternalApi(): Observable<Garage[]> {
    return this.http.get<Garage[]>(`${this.apiUrl}/LoadFromGov`);
  }

  getSavedGarages(): Observable<Garage[]> {
    return this.http.get<Garage[]>(`${this.apiUrl}/GetAllGarages`);
  }

  addGarage(garage: Garage): Observable<any> {
    return this.http.post(`${this.apiUrl}/AddGarage`, garage);
  }
}