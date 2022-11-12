import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { DentistService } from "../models/DentistService";

@Injectable({
  providedIn: "root",
})
export class AdminService {
  constructor(private http: HttpClient) {}

  getAllDentistServices(): Observable<DentistService[]> {
    const req = this.http.get<DentistService[]>("api/admin/dentist-services");

    return req;
  }
}
