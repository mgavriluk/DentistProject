import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Client } from "app/models/client";

@Injectable({
  providedIn: "root",
})
export class ClientsService {
  constructor(private http: HttpClient) {}

  postClient(data: Client) {
    return this.http.post<Client>("api/clients", data);
  }
}
