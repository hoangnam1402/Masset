export const LOGIN = '/login';
export const DASHBOARD = '/dashboard';
export const ASSETS = '/asset';
export const MANAGE_ASSETS = '/asset/*';
export const MANAGE_COMPONENTS = '/component/*';
export const INFO = '/:id';
export const ASSET_ID = (id: string | number) => `/asset/${id}`;
export const COMPONENT_ID = (id: string | number) => `/component/${id}`;
export const COMPONENTS = '/component';
export const MAINTENANCES = '/maintenance';
export const DEPRECIATIONS = '/depreciation';
export const ASSET_TYPES = '/assetType';
export const BRANDS = '/brand';
export const SUPPLIERS = '/supply';
export const LOCATIONS = '/location';
export const USER = '/user';
export const DEPARTMENTS = '/department';

export const NOTFOUND = '/notfound';

// export const CREATE_ASSET = '/asset/createAsset';
// export const EDIT_ASSET = '/asset/edit/:id';
// export const EDIT_ASSET_ID = (id: string | number) => `/asset/edit/${id}`;

export const REPORT= '/report';