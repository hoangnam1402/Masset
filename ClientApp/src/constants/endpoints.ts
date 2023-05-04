const apiurl = "https://localhost:7150/"
const Endpoints = {
	authorize: apiurl+"api/authorize",
	me: apiurl+"api/authorize/me",
	setting: apiurl+"api/setting",

	getDashboard: apiurl+"api/dashboard",

	getUser: apiurl+"api/user",
	getUserId: (id: number | string): string => apiurl + `api/user/${id}`,

	getAsset: apiurl+"api/asset",
	getAllAsset: apiurl+"api/asset/getall",
	getAssetId: (id: number | string): string => apiurl+`api/asset/${id}`,
	generatingQRCode: (tag: number | string): string => apiurl + `api/asset/generatingQRCode//${tag}`,

	getAssetHistory: apiurl+"api/assetHistory",
	getUnreadAssetHistory: apiurl+"api/assetHistory/Unread",
	getAssetHistoryId: (id: number | string): string => apiurl+`api/assetHistory/${id}`,

	getAssetType: apiurl+"api/assetType",
	getAllAssetType: apiurl+"api/assetType/getall",
	getAssetTypeId: (id: number | string): string => apiurl+`api/assetType/${id}`,

	getBrand: apiurl+"api/Brand",
	getAllBrand: apiurl+"api/Brand/getall",
	getBrandId: (id: number | string): string => apiurl+`api/Brand/${id}`,

	getComponent: apiurl+"api/Component",
	getAllComponent: apiurl+"api/Component/getall",
	getComponentId: (id: number | string): string => apiurl+`api/Component/${id}`,

	getDepreciation: apiurl+"api/Depreciation",
	getDepreciationId: (id: number | string): string => apiurl+`api/Depreciation/${id}`,

	getLocation: apiurl+"api/Location",
	getAllLocation: apiurl+"api/Location/getall",
	getLocationId: (id: number | string): string => apiurl+`api/Location/${id}`,

	getMaintenance: apiurl+"api/Maintenance",
	getMaintenanceId: (id: number | string): string => apiurl+`api/Maintenance/${id}`,

	getSupplier: apiurl+"api/Supplier",
	getAllSupplier: apiurl+"api/Supplier/getall",
	getSupplierId: (id: number | string): string => apiurl+`api/Supplier/${id}`,

};

export default Endpoints;
