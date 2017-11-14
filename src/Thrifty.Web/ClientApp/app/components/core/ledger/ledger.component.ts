import { Component, Inject } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

@Component({
    selector: 'ledger',
    templateUrl: './ledger.component.html'
})
export class LedgerComponent {
    public currentCount = 0;

    public ledgers = [];

    public name: string;
    public key: string;


    constructor(private http: Http, @Inject('BASE_URL') private baseUrl: string) {
        this.loadLedgers();
    }

    private loadLedgers() {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        this.http.get(this.baseUrl + 'api/ledger', options).subscribe(result => {
            this.ledgers = result.json();
            console.log("Transaction created!");
        }, error => console.error(error));
    }

    public incrementCounter() {
        this.currentCount++;
    }

    public deleteLedger(key: string) {
        console.log('delete: ' + key);

        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        this.http.delete(this.baseUrl + 'api/ledger/' + key, options).subscribe(result => {
            //this.forecasts = result.json() as WeatherForecast[];
            console.log("Ledger deleted!");
            this.loadLedgers();
        }, error => console.error(error));


    }

    public createLedger() {
        console.log(this.name + ', ' + this.key);
        let body = JSON.stringify({ 'name': this.name, 'key': this.key });
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        this.http.post(this.baseUrl + 'api/ledger', body, options).subscribe(result => {
            //this.forecasts = result.json() as WeatherForecast[];
            console.log("Ledger created!");
            this.loadLedgers();
        }, error => console.error(error));
    }
}
