import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { WorkItems } from '../models/work-items';

@Injectable({
  providedIn: 'root'
})
export class WorkItemsService {

  constructor(private _http:HttpClient) { }
   headers:HttpHeaders = new HttpHeaders({
    'Content-Type': 'application/json'
  });

  getAllWorkItems():Observable<WorkItems[]>
  {
    return this._http.get<WorkItems[]>('http://localhost:7062/GetAll');
  }
  DeleteWorkItems(Id:number): Observable<any>
  {
    return this._http.delete(`http://localhost:7062/DeleteByID/${Id}`);
  }
  UpdateWorkItems(data:any): Observable<any>
  {
    var headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this._http.patch(`http://localhost:7062/Update`,data,{headers});
  }
  DeleteSelectedRecoreds(data:any):Observable<any>
  {
    var headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this._http.post(`http://localhost:7062/DeleteSelected`,data,{headers});
  }
  CreateItems(data:any):Observable<any>
  {
    var headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this._http.post(`http://localhost:7062/CreateItem`,data,{headers});
  }



}
