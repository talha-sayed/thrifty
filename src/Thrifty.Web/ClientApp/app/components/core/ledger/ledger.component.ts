import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

@Component({
    selector: 'ledger',
    templateUrl: './ledger.component.html'
})
export class LedgerComponent {
    public currentCount = 0;

    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        
    }

    public incrementCounter() {
        this.currentCount++;
    }

    public createLedger() {

        let body = JSON.stringify({ 'value': 'bar' });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        this.http.post(this.baseUrl + 'api/ledger', body, options).subscribe(result => {
            //this.forecasts = result.json() as WeatherForecast[];
            console.log("Ledger created!");
        }, error => console.error(error));
    }
}
