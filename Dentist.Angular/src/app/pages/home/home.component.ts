import { Component, OnInit } from "@angular/core";

@Component({
  selector: "home-cmp",
  moduleId: module.id,
  templateUrl: "home.component.html",
})
export class HomeComponent implements OnInit {
  ngOnInit() {}

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

  clientFirstName: string = "";
  clientLastName: string = "";
  clientPhoneNumber: string = "";
  clientAge: number;
  message: string = "";
}
