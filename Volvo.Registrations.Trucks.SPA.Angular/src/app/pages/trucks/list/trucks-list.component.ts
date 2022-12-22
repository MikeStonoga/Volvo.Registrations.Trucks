import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ITruck } from 'src/app/api-access/trucks/itruck.model';
import { TrucksHttpService } from 'src/app/api-access/trucks/trucks.http.service';
import { ConfirmationDialogComponent } from 'src/sdk/components/confirmation-dialog/confirmation-dialog.component';
import { TableConfiguration } from 'src/sdk/components/table/models/table-configuration.model';
import { TrucksService } from '../trucks.service';

@Component({
  selector: 'app-trucks-list',
  templateUrl: './trucks-list.component.html',
  styleUrls: ['./trucks-list.component.scss']
})
export class TrucksListComponent implements OnInit {

  public get tableConfiguration(): TableConfiguration<ITruck> { return this._tableConfiguration; }
  private _tableConfiguration!: TableConfiguration<ITruck>;

  constructor(
    private readonly service: TrucksService,
    private readonly httpService: TrucksHttpService,
    private readonly matDialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this._tableConfiguration = new TableConfiguration({
      columns: {
        definitions: [
          { title: 'Code', propertyName: 'code', type: 'link', width: 30, onClick: (truck) => this.service.goToRegistryTab(truck) },
          { title: 'Name', propertyName: 'name' },
          { title: 'Model', propertyName: 'model', disableSort: true },
          { title: 'Manufacturing Year', propertyName: 'manufacturingYear' },
          { title: 'Registration Time', propertyName: 'creationTime' },
          { title: 'Last Modification Time', propertyName: 'lastModificationTime' },
        ],
        defaultSort: {
          columnName: 'Code',
          direction: 'desc'
        }
      },
      actions: {
        getData: (options) => this.httpService.getAllForList<ITruck>(options),
        custom: [
          { tooltip: 'Adjust', iconName: 'edit', act: (truck) => this.service.goToRegistryTab(truck) },
          { tooltip: 'Remove', iconName: 'delete', act: (truck) => this.removeIfConfirmed(truck) },
        ]
      },
    }, { title: 'Trucks'});
  }
  removeIfConfirmed(truck: ITruck): void {
    const confirmationDialogData = {
      title: `Are you sure deleting ${truck.name}?`, 
      message: 'This can\'t be undone!'
    };
    this.matDialog.open(ConfirmationDialogComponent, {data: confirmationDialogData})
    .afterClosed()
    .subscribe(response => {
      if (!response || !response.confirmed)
        return;

      this.remove(truck)
    });
  }

  public remove(truck: ITruck) {
    
    this.httpService.remove({ truckId: truck.id }).subscribe(response => {
      if (response instanceof HttpErrorResponse) 
        return;

      this.tableConfiguration.getData();
    });
  }

  public goToNewRegistryTab() {
    this.service.tabsComponent.changeTab({ name: 'New', route: 'registration' });
  }
}
  
