using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PrismPlayground.Core.Regions
{
    public class StackPanelRegionsAdapter : RegionAdapterBase<StackPanel>
    {
        public StackPanelRegionsAdapter(IRegionBehaviorFactory regionBehaviorFactory) 
            : base(regionBehaviorFactory)
        {
        }

        protected override void Adapt(IRegion region, StackPanel regionTarget)
        {
            region.Views.CollectionChanged += (s, e) =>
            {
                switch (e.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        
                        foreach (FrameworkElement item in e.NewItems)
                        {
                            regionTarget.Children.Add(item);
                        }
                        
                        break;

                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        
                        foreach (FrameworkElement item in e.NewItems)
                        {
                            regionTarget.Children.Remove(item);
                        }

                        break;

                }
            };
        }

        protected override IRegion CreateRegion()
        {
            return new Region();
        }
    }
}
