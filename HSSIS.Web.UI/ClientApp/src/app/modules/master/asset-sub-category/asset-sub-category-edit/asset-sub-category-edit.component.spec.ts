import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssetSubCategoryEditComponent } from './asset-sub-category-edit.component';

describe('AssetSubCategoryEditComponent', () => {
  let component: AssetSubCategoryEditComponent;
  let fixture: ComponentFixture<AssetSubCategoryEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AssetSubCategoryEditComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssetSubCategoryEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
