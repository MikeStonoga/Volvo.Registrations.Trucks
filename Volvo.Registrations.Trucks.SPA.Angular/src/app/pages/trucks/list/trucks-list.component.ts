import { Component, OnInit } from '@angular/core';
import { ITruck } from 'src/app/api-access/trucks/itruck.model';
import { TrucksHttpService } from 'src/app/api-access/trucks/trucks.http.service';
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
  ) { }

  ngOnInit(): void {
    this._tableConfiguration = new TableConfiguration({
      columns: {
        definitions: [
          { title: 'Code', propertyName: 'code', type: 'link', width: 30, onClick: (truck) => this.service.goToRegistryTab(truck) },
          { title: 'Name', propertyName: 'name' },
          { title: 'Model', propertyName: 'model' },
          { title: 'Manufacturing Year', propertyName: 'manufacturingYear' },
          { title: 'Registration Time', propertyName: 'creationTime' },
          { title: 'Last Modification Time', propertyName: 'lastModificationTime' },

        ],
        defaultSort: {
          columnName: 'ManufacturingYear',
          direction: 'desc'
        }
      },
      actions: {
        getData: (options) => this.httpService.getAllForList<ITruck>(options)
      },
    });
  }

  public goToNewRegistryTab() {
    this.service.tabsComponent.changeTab({ name: 'New', route: 'registration' });
  }
}
  
