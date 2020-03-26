import { Component, Inject } from '@angular/core';
import { AuthorizeService } from '../../api-authorization/authorize.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, tap } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public userCalculation: UserCalculationModel;
  public userCalculations: UserCalculationModel[];  
  public isAuthenticated: Observable<boolean>;
  public userName: Observable<string>;
  public baseApiUrl: string;
  public http: HttpClient;

  constructor(http: HttpClient, private authorizeService: AuthorizeService) {
    //todo:get from service
    this.baseApiUrl = "https://localhost:44360/";

    this.http = http;
    this.userCalculation = {
      agentAmount: 0,
      cropType: "",
      description: "",
      hectares: 0,
      id: 0,
      litersPerHectare: 0,
      minimimSprayRate: 0,
      sprayingAgent: "",
      userId: null,
      waterAmount: 0
    };
  }
  onKey() {
    this.userCalculation.agentAmount = this.userCalculation.litersPerHectare * this.userCalculation.hectares;
    this.userCalculation.waterAmount = this.userCalculation.minimimSprayRate * this.userCalculation.hectares;
  }

  newCalculation() {
    this.userCalculation = {
      agentAmount: 0,
      cropType: "",
      description: "",
      hectares: 0,
      id: 0,
      litersPerHectare: 0,
      minimimSprayRate: 0,
      sprayingAgent: "",
      userId: this.userCalculation.userId,
      waterAmount: 0
    };
  }

  saveCalculation() {

    if (this.userCalculation.id > 0) {
      this.updateCalculation();
    }
    else {
      this.createCalculation();
    }
  }

  createCalculation() {

    this.http.post<UserCalculationModel>(this.baseApiUrl + 'UserCalculation/create', this.userCalculation).subscribe(result => {
      console.log(result);
      this.userCalculations.push(result);
      this.userCalculation.id = result.id;
    }, error => console.error(error));
  }

  updateCalculation() {

    this.http.put<UserCalculationModel>(this.baseApiUrl + 'UserCalculation/update', this.userCalculation).subscribe(result => {
      var index = this.userCalculations.findIndex(x => x.id == result.id);
      this.userCalculations[index] = result;
    }, error => console.error(error));
  }
  getCalculations(userId: string) {

    this.http.post<UserCalculationModel[]>(this.baseApiUrl + 'UserCalculation/GetUserCalculationFilter', { UserId: userId}).subscribe(result => {
      this.userCalculations = result;
    }, error => console.error(error));
  }
  deleteCalculation(id: number) {

    this.http.delete(this.baseApiUrl + `UserCalculation/delete/${id}`).subscribe(result => {
      var index = this.userCalculations.findIndex(x => x.id == id);
      this.userCalculations.splice(index, 1);
      if (this.userCalculation.id == id) {
        this.userCalculation.id = 0;
      }
    }, error => console.error(error));
  }


  loadCalculation(id: number) {
      this.userCalculation = this.userCalculations.find(x => x.id == id);
  }

  ngOnInit() {
    this.isAuthenticated = this.authorizeService.isAuthenticated();
    this.userName = this.authorizeService.getUser().pipe(map(u => u && u.name));
    this.userName.subscribe(val => {
      this.userCalculation.userId = val;
      this.getCalculations(val);
    });
  }
}

//todo: find a better spot for this
interface UserCalculationModel {
  id: number
  userId: string
  description: string
  hectares: number
  minimimSprayRate: number
  litersPerHectare: number
  agentAmount: number
  waterAmount: number
  cropType: string
  sprayingAgent: string
}
