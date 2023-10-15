import { createReducer, on } from "@ngrx/store";
import { changeLoading } from "./loading.actions";
import { state } from "@angular/animations";

export const INITIAL_STATE:boolean=false

export const loadingReducer=createReducer(
    INITIAL_STATE,
    on(changeLoading,(state)=>!state)
)