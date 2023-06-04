const apiurl = "https://localhost:7150/"
const Endpoints = {
	authorize: apiurl+"api/authorize",
	me: apiurl+"api/authorize/me",
	Setting: apiurl+"api/setting",
	Logo: apiurl+"api/setting/upload-image",

	Dashboard: apiurl+"api/dashboard",
	AssetChecking: apiurl+"api/checking/AssetActive",
	ComponentChecking: apiurl+"api/checking/ComponentActive",

	User: apiurl+"api/user",
	UserId: (id: number | string): string => apiurl + `api/user/${id}`,
	AllUser: apiurl+"api/user/getall",

	Asset: apiurl+"api/asset",
	AllAsset: apiurl+"api/asset/getall",
	AllForDepreciation: apiurl+"api/asset/getAllForDepreciation",
	AssetId: (id: number | string): string => apiurl+`api/asset/${id}`,
	generatingQRCode: (tag: string): string => apiurl + `api/asset/generatingQRCode/${tag}`,
	MaintenanceOfAsset: (id: number | string): string => apiurl+`api/maintenance/getOfAsset/${id}`,
	DepreciationOfAsset: (id: number | string): string => apiurl+`api/depreciation/getOfAsset/${id}`,
	History: (id: number | string): string => apiurl+`api/checking/historyOfAsset/${id}`,
	ComponentOfAsset: (id: number | string): string => apiurl+`api/checking/componentOfAsset/${id}`,
	AssetCheckIn: apiurl+"api/checking/checkInAsset",
	AssetCheckOut: apiurl+"api/checking/checkOutAsset",

	AssetHistory: apiurl+"api/assetHistory",
	UnreadAssetHistory: apiurl+"api/assetHistory/Unread",
	AssetHistoryId: (id: number | string): string => apiurl+`api/assetHistory/${id}`,

	AssetType: apiurl+"api/assetType",
	AllAssetType: apiurl+"api/assetType/getall",
	AssetTypeId: (id: number | string): string => apiurl+`api/assetType/${id}`,

	Brand: apiurl+"api/Brand",
	AllBrand: apiurl+"api/Brand/getall",
	BrandId: (id: number | string): string => apiurl+`api/Brand/${id}`,

	Component: apiurl+"api/component",
	AllComponent: apiurl+"api/component/getall",
	ComponentId: (id: number | string): string => apiurl+`api/component/${id}`,
	DepreciationOfComponent: (id: number | string): string => apiurl+`api/depreciation/getOfComponent/${id}`,
	ComponentCheckIn: (id: number | string): string => apiurl+`api/checking/checkInComponent/${id}`,
	ComponentCheckOut: apiurl+"api/checking/checkOutComponent",
	ActiveOfComponent: (id: number | string): string => apiurl+`api/checking/activeOfComponent/${id}`,

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

	CheckId: (id: number | string): string => apiurl+`api/checking/${id}`,
};

export default Endpoints;
