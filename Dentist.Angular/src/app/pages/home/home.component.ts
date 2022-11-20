import { Component, OnInit } from "@angular/core";
import { Client } from "app/models/client";
import { ClientsService } from "app/services/clients.service";
import { DentistServicesService } from "app/services/dentist-services.service";
import { IDentistService } from "../../../../projects/admin-layout/src/app/models/dentist-service";

@Component({
  selector: "home-cmp",
  moduleId: module.id,
  templateUrl: "home.component.html",
})
export class HomeComponent implements OnInit {
  dentistServicesList: IDentistService[] = [];
  client: Client = new Client();
  clientPhoneNumber: string = "";

  constructor(
    private dentistServiceService: DentistServicesService,
    private clientService: ClientsService
  ) {}

  ngOnInit() {
    this.dentistServiceService
      .getUnpaginatedDentistServices()
      .subscribe((res) => {
        this.dentistServicesList = res;
      });
  }

  display: any;
  center: google.maps.LatLngLiteral = { lat: 46.4693317, lng: 30.74847 };
  zoom: 4;
  markerPosition: google.maps.LatLngLiteral = {
    lat: 46.4693317,
    lng: 30.74847,
  };
  markerOptions: google.maps.MarkerOptions = { draggable: false };

  moveMap(event: google.maps.MapMouseEvent) {
    if (event.latLng != null) this.center = event.latLng.toJSON();
  }

  move(event: google.maps.MapMouseEvent) {
    if (event.latLng != null) this.display = event.latLng.toJSON();
  }
  submit(form) {
    this.clientService.postClient(this.client).subscribe({
      next: () => {
        alert("С Вами свяжутся в ближайшее время");
      },
      error: () => {
        alert("Ошибка");
      },
    });

    form.resetForm();
  }
}
