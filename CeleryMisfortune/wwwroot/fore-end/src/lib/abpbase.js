import appconst from './appconst'
export const AbpBase = {
  methods: {
    L (value, source, ...argus) {
      if (source) {
        return window.abp.localization.localize(value, source, argus)
      } else {
        return window.abp.localization.localize(value, appconst.localization.defaultLocalizationSourceName, argus)
      }
    },
    hasPermission (permissionName) {
      return window.abp.auth.hasPermission(permissionName)
    },
    hasAnyOfPermissions (...argus) {
      return window.abp.auth.hasAnyOfPermissions(...argus)
    },
    hasAllOfPermissions (...argus) {
      return window.abp.auth.hasAllOfPermissions(...argus)
    }
  }
}
