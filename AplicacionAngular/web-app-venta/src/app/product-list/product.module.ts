import {NgModule} from '@angular/core';
import {CommonModule} from  '@angular/common';
import {FormsModule} from '@angular/forms';
import { ProductListComponent } from './product-list.component';
import { ProductRoutingModule } from './product-routing.module';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSliderModule } from '@angular/material/slider';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatSelectModule } from '@angular/material/select';
@NgModule({
    declarations: [ProductListComponent],
    imports:[CommonModule,ProductRoutingModule,FormsModule,   MatInputModule,
        MatPaginatorModule,
        MatProgressSpinnerModule,
        MatSortModule,
        MatTableModule,
        MatIconModule,
        MatButtonModule,
        MatCardModule,
        MatFormFieldModule,
        MatSliderModule,
        MatSlideToggleModule,
        MatButtonToggleModule,
        MatSelectModule]
})
export class ProductModule{}