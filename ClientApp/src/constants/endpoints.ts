const apiurl = "https://localhost:7150/"
const Endpoints = {
	authorize: apiurl+"api/authorize",
	me: apiurl+"api/authorize/me",
	setting: apiurl+"api/setting",

	Dashboard: apiurl+"api/dashboard",

	User: apiurl+"api/user",
	UserId: (id: number | string): string => apiurl + `api/user/${id}`,

	Asset: apiurl+"api/asset",
	AllAsset: apiurl+"api/asset/getall",
	AssetId: (id: number | string): string => apiurl+`api/asset/${id}`,
	generatingQRCode: (tag: string): string => apiurl + `api/asset/generatingQRCode/${tag}`,
	MaintenanceOfAsset: (id: number | string): string => apiurl+`api/maintenance/getOfAsset/${id}`,
	DepreciationOfAsset: (id: number | string): string => apiurl+`api/depreciation/getOfAsset/${id}`,

	AssetHistory: apiurl+"api/assetHistory",
	UnreadAssetHistory: apiurl+"api/assetHistory/Unread",
	AssetHistoryId: (id: number | string): string => apiurl+`api/assetHistory/${id}`,

	AssetType: apiurl+"api/assetType",
	AllAssetType: apiurl+"api/assetType/getall",
	AssetTypeId: (id: number | string): string => apiurl+`api/assetType/${id}`,

	Brand: apiurl+"api/Brand",
	AllBrand: apiurl+"api/Brand/getall",
	BrandId: (id: number | string): string => apiurl+`api/Brand/${id}`,

	Component: apiurl+"api/Component",
	AllComponent: apiurl+"api/Component/getall",
	ComponentId: (id: number | string): string => apiurl+`api/Component/${id}`,
	DepreciationOfComponent: (id: number | string): string => apiurl+`api/depreciation/getOfComponent/${id}`,

	Depreciation: apiurl+"api/Depreciation",
	DepreciationId: (id: number | string): string => apiurl+`api/Depreciation/${id}`,

	Location: apiurl+"api/Location",
	AllLocation: apiurl+"api/Location/getall",
	LocationId: (id: number | string): string => apiurl+`api/Location/${id}`,

	Maintenance: apiurl+"api/Maintenance",
	MaintenanceId: (id: number | string): string => apiurl+`api/Maintenance/${id}`,

	Supplier: apiurl+"api/Supplier",
	AllSupplier: apiurl+"api/Supplier/getall",
	SupplierId: (id: number | string): string => apiurl+`api/Supplier/${id}`,

};

export default Endpoints;
