import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { IDentistService } from "app/models/dentist-service";

@Injectable({
  providedIn: "root",
})
export class DentistServicesService {
  constructor(private http: HttpClient) {}

  getUnpaginatedDentistServices() {
    return this.http.get<IDentistService[]>("api/services");
  }
}
