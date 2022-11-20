import { AfterViewInit, Component, OnInit, ViewChild } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { MatPaginator, PageEvent } from "@angular/material/paginator";
import { AddClientDialogComponent } from "../../components/add-client-dialog/add-client-dialog.component";
import { IClient } from "../../models/client";
import { AdminService } from "../../services/admin.service";

@Component({
  selector: "app-clients",
  templateUrl: "./clients.component.html",
  styleUrls: ["./clients.component.css"],
})
export class ClientsComponent implements AfterViewInit, OnInit {
  clientsList: IClient[] = [];
  isBusy: boolean = false;
  total: number = 0;
  pageSize: number = 5;
  pageEvent: PageEvent;
  pageIndex: number = 0;
  constructor(private adminService: AdminService, private dialog: MatDialog) {}

  ngOnInit(): void {
    this.fetch();
  }

  ngAfterViewInit(): void {
    this.paginator.page.subscribe((page) => {
      this.pageSize = page.pageSize;
      this.pageIndex = page.pageIndex;
      this.fetch();
    });
  }

  fetch() {
    this.isBusy = true;
    this.adminService
      .getClients(this.pageIndex, this.pageSize, "", "")
      .subscribe((res) => {
        this.clientsList = res.items;
        this.total = res.total;
        this.pageSize = res.pageSize;
        this.pageIndex = res.pageIndex;
      });
    this.isBusy = false;
  }
  displayedColumns: string[] = ["firstName", "lastName", "age", "actions"];
  @ViewChild(MatPaginator) paginator: MatPaginator;

  abc() {
    console.log(this.clientsList);
  }

  // openDialog() {
  //   this.dialog
  //     .open(AddClientDialogComponent, {
  //       width: "30%",
  //     })
  //     .afterClosed()
  //     .subscribe((val) => {
  //       if (val === "save") {
  //         this.fetch();
  //       }
  //     });
  // }

  // editService(row) {
  //   this.dialog
  //     .open(AddClientDialogComponent, {
  //       width: "30%",
  //       data: row,
  //     })
  //     .afterClosed()
  //     .subscribe((val) => {
  //       if (val === "update") {
  //         this.fetch();
  //       }
  //     });
  // }

  // deleteService(id: number) {
  //   if (confirm("Вы действительно хотите удалить клиента?")) {
  //     this.adminService.deleteClient(id).subscribe({
  //       next: () => {
  //         alert("клиент удален");
  //         this.fetch();
  //       },
  //       error: () => {
  //         alert("Ошибка");
  //       },
  //     });
  //   }
  // }
}
