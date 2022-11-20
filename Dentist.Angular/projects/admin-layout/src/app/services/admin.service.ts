import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { IDentistService } from "../models/dentist-service";
import { IPaginatedResult } from "../models/paginated-result";
import { IClient } from "../models/client";

export interface DentistServicesData {
  items: IDentistService[];
}

@Injectable({
  providedIn: "root",
})
export class AdminService {
  constructor(private http: HttpClient) {}

  getDentistServices(
    pageIndex: number,
    pageSize: number,
    columnNameForSorting: string,
    sortDirection: string
  ): Observable<IPaginatedResult<IDentistService>> {
    let params = new HttpParams();

    params = params.append("PageIndex", String(pageIndex));
    params = params.append("PageSize", String(pageSize));
    params = params.append("ColumnNameForSorting", "%22%22");
    params = params.append("SortDirection", "%22%22");

    return this.http.get<IPaginatedResult<IDentistService>>(
      "/api/admin/dentist-services",
      {
        params,
      }
    );
  }

  postDentistService(data: IDentistService) {
    return this.http.post<IDentistService>("api/admin/dentist-services", data);
  }

  putDentistService(data: IDentistService, id: number) {
    return this.http.put<IDentistService>(
      "api/admin/dentist-services/" + id,
      data
    );
  }

  deleteDentistService(id: number) {
    return this.http.delete<IDentistService>(
      "api/admin/dentist-services/" + id
    );
  }

  getClients(
    pageIndex: number,
    pageSize: number,
    columnNameForSorting: string,
    sortDirection: string
  ): Observable<IPaginatedResult<IClient>> {
    let params = new HttpParams();

    params = params.append("PageIndex", String(pageIndex));
    params = params.append("PageSize", String(pageSize));
    params = params.append("ColumnNameForSorting", "%22%22");
    params = params.append("SortDirection", "%22%22");

    return this.http.get<IPaginatedResult<IClient>>("/api/admin/clients", {
      params,
    });
  }

  postClient(data: IClient) {
    return this.http.post<IClient>("api/admin/clients", data);
  }

  putClient(data: IClient, id: number) {
    return this.http.put<IClient>("api/admin/clients/" + id, data);
  }

  deleteClient(id: number) {
    return this.http.delete<IClient>("api/admin/clients/" + id);
  }
}
