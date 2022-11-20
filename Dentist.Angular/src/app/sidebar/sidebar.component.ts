import { Component, OnInit } from "@angular/core";

export interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
}

export const ROUTES: RouteInfo[] = [
  { path: "/main", title: "Главная", icon: "nc-bank", class: "" },
  { path: "/about_me", title: "Обо мне", icon: "nc-single-02", class: "" },
  { path: "/services", title: "Мои услуги", icon: "nc-paper", class: "" },
  {
    path: "/contacts",
    title: "Контакты",
    icon: "nc-bullet-list-67",
    class: "",
  },
  {
    path: "/appointment",
    title: "Расположение",
    icon: "nc-map-big",
    class: "",
  },
];

@Component({
  moduleId: module.id,
  selector: "sidebar-cmp",
  templateUrl: "sidebar.component.html",
})
export class SidebarComponent implements OnInit {
  public menuItems: any[];
  ngOnInit() {
    this.menuItems = ROUTES.filter((menuItem) => menuItem);
  }
}
