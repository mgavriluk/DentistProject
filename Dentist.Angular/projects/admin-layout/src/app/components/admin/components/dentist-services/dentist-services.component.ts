import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { DentistService } from "../../models/DentistService";
import { AdminService } from "../../services/admin.service";

@Component({
  selector: "app-dentist-services",
  templateUrl: "./dentist-services.component.html",
  styleUrls: ["./dentist-services.component.css"],
})
export class DentistServicesComponent implements OnInit {
  dentistServicesList!: Observable<DentistService[]>;

  constructor(private adminService: AdminService) {}

  ngOnInit(): void {
    this.dentistServicesList = this.adminService.getAllDentistServices();
  }

  getAllDenistServices() {}
}
