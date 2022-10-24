import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Shippers } from 'src/app/models/shippers/shippers';
import { ShippersRequest } from 'src/app/models/shippers/shippersRequest';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiCrudService {

  endpoint : string = "api/Shippers";

  constructor(private http: HttpClient) { }

  get(id: number): Observable<Shippers> {
    return this.http.get<Shippers>(`${environment.apiNorthwind}/${this.endpoint}/${id}`);
  }

  getShippers(): Observable<Shippers[]> {
    return this.http.get<Shippers[]>(`${environment.apiNorthwind}/${this.endpoint}`);
  }

  addShippers(requestNewShipper: ShippersRequest): Observable<any> { //TODO: cambiar generics any
    return this.http.post(`${environment.apiNorthwind}/${this.endpoint}`, requestNewShipper);
  }

  updateShippers(shipperEdited: Shippers): Observable<any> { //TODO: cambiar generics any
    return this.http.put(`${environment.apiNorthwind}/${this.endpoint}`, shipperEdited);
  }

  deleteShipper(id: number):  Observable<any> { //TODO: cambiar generics any
    return this.http.delete(`${environment.apiNorthwind}/${this.endpoint}/${id}`);
  }
}
