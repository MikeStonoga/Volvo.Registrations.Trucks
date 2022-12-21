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
          { title: 'Código', propertyName: 'codigo', type: 'link', onClick: (pessoa) => this.service.goToRegistryTab(pessoa) },
          { title: 'Nome', propertyName: 'nome' },
          { title: 'Nascimento', propertyName: 'dataDeNascimento', type: 'date' }
        ],
        defaultSort: {
          columnName: 'Codigo',
          direction: 'desc'
        }
      },
      actions: {
        getData: (options) => this.httpService.getAllForList<ITruck>(options)
      },
    });
  }

  public goToNewRegistryTab() {
    this.service.tabsComponent.changeTab({ name: 'New', route: 'new' });
  }
}
  
