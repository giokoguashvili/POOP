using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using Swift.Infrastructure.Infrastructure;

namespace Swift.Transformation.Rules.Engine.MEF
{

    public class AttributedParts<T> : IContent<IEnumerable<Lazy<T, IDictionary<string, object>>>>
    {
        [ImportMany]
        private IEnumerable<Lazy<T, IDictionary<string, object>>> Plugins { get; set; }

        private readonly Lazy<IEnumerable<Lazy<T, IDictionary<string, object>>>> _layzLazyAttributedParts;
        public AttributedParts(string dllsPath) 
            : this(new DirectoryCatalog(dllsPath))
        {}
        public AttributedParts(ComposablePartCatalog composablePartCatalog)
            : this(new CompositionContainer(composablePartCatalog))
        {}
        public AttributedParts(CompositionContainer compositionContainer)
        {
            _layzLazyAttributedParts = new Lazy<IEnumerable<Lazy<T, IDictionary<string, object>>>>(() =>
            {
                compositionContainer.ComposeParts(this);
                return Plugins;
            });
        }
        public IEnumerable<Lazy<T, IDictionary<string, object>>> Content()
        {
            return _layzLazyAttributedParts.Value;
        }
    }

}
