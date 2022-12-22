import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ITruck } from 'src/app/api-access/trucks/itruck.model';
import { TrucksHttpService } from 'src/app/api-access/trucks/trucks.http.service';
import { TrucksService } from '../trucks.service';

@Component({
  selector: 'app-truck-registry',
  templateUrl: './truck-registry.component.html',
  styleUrls: ['./truck-registry.component.scss']
})
export class TruckRegistryComponent implements OnInit {

  public form!: FormGroup;
  public get canSave(): boolean { return this.form.dirty && this.form.valid; }

  public truck?: ITruck;
  public isRegistering!: boolean;
  public isLoaded: boolean = false;
  
  constructor(
    private readonly formBuilder: FormBuilder,
    private readonly service: TrucksService,
    private readonly httpService: TrucksHttpService,
    private readonly route: ActivatedRoute,
  ) {
    const truckId = this.route.snapshot.params['id'];
    const isAdjusting = !!truckId;
    this.isRegistering = !isAdjusting;

    if (isAdjusting) {
      this.httpService.getById(truckId).subscribe((truck) => {
        this.truck = truck
        this.initializeForm();
        this.isLoaded = true;
      });
    } else {
      this.initializeForm();
      this.isLoaded = true;
    }
  }

  private initializeForm() {
    this.form = this.formBuilder.group({
      TruckId: [this.truck?.id],
      ModelId: [this.truck?.modelId]
    });
  }

  ngOnInit(): void {
  }

  public register() {
    if (!this.canSave)
      return;

    this.httpService.register(this.form.getRawValue()).subscribe((response) => {
      if (response instanceof HttpErrorResponse) 
        return;

      this.service.tabsComponent.removeCurrentTab();
      this.service.goToRegistryTab(response.truck);
      this.form.markAsPristine();
    });
  }

  public adjust() {
    if (!this.canSave)
      return;

    this.httpService.adjust(this.form.getRawValue()).subscribe((response) => {
      if (response instanceof HttpErrorResponse) 
        return;

      this.service.tabsComponent.removeCurrentTab();
      this.service.goToRegistryTab(response.truck);
      this.form.markAsPristine();
    });
  }

}
