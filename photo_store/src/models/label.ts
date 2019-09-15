import { Instances } from './instances';

export interface ILabel {
    confidence: number;
    instances: Instances[];
    name: string;
    parents: IParent[];
}

export interface IParent {
    name: string;
}