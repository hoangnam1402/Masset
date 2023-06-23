export const LOGIN = '/login';
export const DASHBOARD = '/dashboard';
export const ASSETS = '/property';
export const MANAGE_ASSETS = '/property/*';
export const MANAGE_COMPONENTS = '/component/*';
export const INFO = '/:id';
export const ASSET_ID = (id: string | number) => `/property/${id}`;
export const COMPONENT_ID = (id: string | number) => `/component/${id}`;
export const COMPONENTS = '/component';
export const MAINTENANCES = '/maintenance';
export const DEPRECIATIONS = '/depreciation';
export const ASSET_TYPES = '/assetType';
export const BRANDS = '/brand';
export const SUPPLIERS = '/supply';
export const LOCATIONS = '/location';
export const USER = '/user';
export const SETTING = '/setting';

export const NOTFOUND = '/notfound';

export const REPORT= '/report';