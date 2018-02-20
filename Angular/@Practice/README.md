## Angular 2

### CLI Commands
`npm install -g @angular/cli` - install angular cli  
`ng new my-app-name` - create new app  
`ng serve --open` - serve and open app in browser  
`ng generate component comp-name` - create new component  
`ng generate service service-name --module=app` - create new service and module


## Basic structure
- modules - lists components and bootstraps
- components - basic part of angular - exports a single directive
- directives, templates - html files with extendable content

### Directives
- `{{ }}` - interpolates property from component class
```html
<div class="panel-heading">{{pageTitle}}</div>
```
- `*ngIf` - defines if statement to render or not the element and its children
```html
<table class="table" *ngIf="products && products.length">
```
- `*ngFor` - repeats statements for each item in a list
```html
<tr *ngFor='let product of products'>
    <td>{{property-a}}</td>
    <td>{{property-b}}</td>
</tr>
```

### Data binding - 2 way binding
- Property pinding 
```html
<img [src]='product.imageUrl' [style.width.px]='imageWidth'>
```
- Event binding
```html
<button (click)='toggleImage()'>
```
- Two way binding
```html
<input [(ngModel)]='listFilter'>
```

### Pipes
```html
{{ product.productCode | lowercase }}
<img [src]=product.imageUrl'' [title]='product.productName | uppercase'>
```
- pipes chaining
```html
{{ product.price | currency | lowercase }}
```
- pipe parameters
```html
{{ product.price | currency:'USD':true:'1.2-2' }}
```

### Custom pipes
```ts
@Pipe({
    name:'productFilter';
})

export class ProductFilterPipe implements PipeTransform {
    transform(value: IProduct[], filterBy: string) : IProduct[] {

    }
}
```

### Interfases
```ts
export interface IProduct {
    productId: number;
    ProductName: string;
}
```

### Component Styles
- Encapsulate styles
```ts
@Component({
    styles: ['thead { color: #337AB7 }'],
    styleUrls: ['./this.component.style.css']
})
```

### Component life-cycle
- OnInit
```ts
class ProductListComponent implements OnInit {
    ngOnInit(): void {
       throw new Error("Method not implemented.");
    }
}
```
- OnChanges
- OnDestroy

### Module Id - removes absolute paths
- use commonJS module format
- requires systemjs or other module loader
```ts
@Component({
    // other properties
    moduleId: module.id,
    templateUrl: 'product-list.component.html'
})
```

### Nesting components
- as a directive - like an html tag from `selector`
- as a routing target
- use `@input`- to get a property from the container
```ts
export class StarComponent implements OnChanges{
    @Input() rating: number = 4;
    starWidth: number;

    ngOnChanges(): void {
        this.starWidth = this.rating * 86/5;
    }
}
```
```html
<ai-star [rating]='product.starRating'></ai-star>
```
- use `@Output` - raise event or pass information back to container
1. in the nested component
```ts
export class StarComponent implements OnChanges{
    // other properties
    @Output() ratingClicked: EventEmitter<string> =
    new EventEmitter<string>();

    onClick(): void {
        this.ratingClicked.emit(`The rating ${this.rating} was clicked!`);
    }
}
```
```html
<div class="crop" [title]="rating" (click)='onClick()'>
```
2. in the external component
```ts
export class ProductListComponent implements OnInit {
    // other properties
    onRatingClicked(message: string): void {
        this.pageTitle = 'Product List: ' + message;
    }
}
```
```html
<ai-star [rating]='product.starRating' 
(ratingClicked)='onRatingClicked($event)'></ai-star>
```

## Services and Dependency Injection
- independant from particular component
- share information to components
- work with external data

1. create service (class, decorator, import)
```ts
import { Injectable } from "@angular/core";

@Injectable() // injectable decorator

export class ProductService {
        GetProducts(): IProduct[] {
        return [/* products */];
    }
}
```
2. Register the service
 - at the root (app.component)
 ```ts
 @Component({
  // other properties
  providers: [ ProductService ]
})
 ```
 - at a modile

3. Inject service to class constructor
```ts
constructor(private _productService: ProductService) {}
ngOnInit(): void {
    this.products =  this._productService.GetProducts();
}
```

## HTTP Data Calls, observables (similar to promises)
- import `HttpService` in module
- create `Observable<Response>` in local service
- `map` transform response to usable data type

1. Expose Observable from data service
```ts
GetProducts(): Observable<IProduct[]> {
        return this._http.get(this._productUrl)
            .map((response: Response) => <IProduct[]>response.json())
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error!');
    }
```
2. Subscribe to the observable in the component class
```ts
    ngOnInit(): void {
        this._productService.GetProducts()
        .subscribe(products => this.products = products,
        error => this.errorMessage = <any>error);
    }
```

## Routing
- import RouterModile
```ts
RouterModule.forRoot([], { useHash: true })
```
- create routes in @NgModule decorator in app.module
```ts
{ path: 'products', component: ProductListComponent } // standard
{ path: 'product/:id', component: ProductDetailsComponent } // standard
{ path: 'welcome', component: WelcomeComponent },
{ path: '', redirectTo: 'welcome', pathMatch: 'full' } // default
{ path: '**', component: PageNotFoundCOmponent } // for 404 not found page
```
- add routes to main template and a container to display content
```html
<li><a [routerLink]="['/welcome']">Home</a></li>
<li><a [routerLink]="['/products']">Product List</a></li>

<div class="container">
    <router-outlet></router-outlet>
</div>
```

#### Routes with parameters
```html
<a [routerLink]="['/product', product.productId]">{{product.ProductName}}</a>
```

## Guards
- Can activate
- Can Deactivate
- Resolve
```ts
import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router } from "@angular/router";

@Injectable()

export class ProductDetailGuard implements CanActivate {
    constructor(private _router: Router) {
    }

    canActivate(route: ActivatedRouteSnapshot): boolean {
        let id = +route.url[1].path;
        if (isNaN(id) || id < 1) {
            alert('Invalid product Id');
            // abort current navigation
            return false;
        };
        return true;
    }
}
```
