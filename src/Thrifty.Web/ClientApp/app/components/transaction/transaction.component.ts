import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

@Component({
    selector: 'transaction',
    templateUrl: './transaction.component.html'
})
export class TransactionComponent {
    public currentCount = 0;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        
    }

    public incrementCounter() {
        this.currentCount++;
    }

    public createTransaction() {

        let body = JSON.stringify({ 'value': 'bar' });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        this.http.post(this.baseUrl + 'api/Transaction', body, options).subscribe(result => {
            //this.forecasts = result.json() as WeatherForecast[];
            console.log("Transaction created!");
        }, error => console.error(error));
    }
}
