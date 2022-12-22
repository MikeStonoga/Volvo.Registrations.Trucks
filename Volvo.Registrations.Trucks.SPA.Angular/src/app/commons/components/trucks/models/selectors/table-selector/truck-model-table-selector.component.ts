import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ITruckModel } from 'src/app/api-access/trucks/dtos/itruck-model.model';
import { TrucksModelsHttpService } from 'src/app/api-access/trucks/models/trucks-models.http.service';
import { TableConfiguration } from 'src/sdk/components/table/models/table-configuration.model';

@Component({
  selector: 'app-truck-model-table-selector',
  templateUrl: './truck-model-table-selector.component.html',
  styleUrls: ['./truck-model-table-selector.component.scss']
})
export class TruckModelTableSelectorComponent implements OnInit {
  public tableConfiguration: TableConfiguration<ITruckModel>;


  constructor(
    @Inject(MAT_DIALOG_DATA) private readonly alreadySelectedId: string,
    public dialogRef: MatDialogRef<TruckModelTableSelectorComponent>,
    private readonly httpService: TrucksModelsHttpService,
  ) {
    this.tableConfiguration = new TableConfiguration({
      columns: {
        definitions: [
          { title: 'Name',  propertyName: 'name', onClick: (model) => this.selectModel(model) },
          { title: 'Year',  propertyName: 'year', onClick: (model) => this.selectModel(model) },
        ],
        defaultSort: {
          columnName: 'Name',
          direction: 'asc'
        }
      },
      actions: {
        getData: (options) => this.httpService.getAllForList(options, !!this.alreadySelectedId ? [this.alreadySelectedId] : [])
      }
    });
  }

  public selectModel(model: ITruckModel): void {
    this.dialogRef.close({ mustAdd: true, data: { id: model.id, value: `${model.name} / ${model.year}`}})
  }

  ngOnInit(): void {
  }
  
}
