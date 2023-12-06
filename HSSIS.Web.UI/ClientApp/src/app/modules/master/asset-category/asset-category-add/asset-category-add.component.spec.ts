import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetCategoryAddComponent } from './asset-category-add.component';

describe('AssetCategoryAddComponent', () => {
  let component: AssetCategoryAddComponent;
  let fixture: ComponentFixture<AssetCategoryAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssetCategoryAddComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssetCategoryAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
