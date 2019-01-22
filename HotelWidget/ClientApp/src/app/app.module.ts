import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HotelService } from './services/hotel.service';
import { TyohotelComponent } from './hotel/tyohotel.component';
import { NyhotelComponent } from './hotel/nyhotel.component';
import { StarComponent } from './star/star.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NyhotelComponent,
    TyohotelComponent,
    StarComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' }
    ])
  ],
  providers: [HotelService],
  bootstrap: [AppComponent]
})
export class AppModule { }
